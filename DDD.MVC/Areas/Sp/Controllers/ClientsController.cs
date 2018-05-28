using AutoMapper;
using DDD.Application.Interfaces;
using DDD.Domain.Models;
using DDD.MVC.Areas.Sp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DDD.MVC.Areas.Sp.Controllers
{
	
    public class ClientsController : Controller
    {
		private readonly IClientAppService _clientAppService;
		private readonly IPhoneAppService _phoneAppService;
		public ClientsController(IClientAppService clientAppService, IPhoneAppService phoneAppService)
		{
			_clientAppService = clientAppService;
			_phoneAppService = phoneAppService;
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["ExemploClienteSp"].ConnectionString;
			_clientAppService.SetContext(conn);
			_phoneAppService.SetContext(conn);

		}
        // GET: Sp/Clients        
		public ActionResult Index(DateTime? birthDay, string cpf = "")
		{
			var clients = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_clientAppService.GetAll());
			clients = clients
				.Where(c =>
					(birthDay != null ? c.BirthDay == birthDay : true) &&
					(!string.IsNullOrEmpty(cpf) ? c.Cpf.Contains(cpf) : true)
			);
			ObjIndex obj = new ObjIndex();
			obj.Cpf = cpf;
			obj.BirthDay = birthDay;
			obj.Clients = clients;
			return View(obj);
		}

		// GET: Sp/Clients/Details/5
		public ActionResult Details(int id)
        {
            return View();
        }

        // GET:Sp/Clients/Create
        public ActionResult Create()
        {
            return View(new ClientViewModel());
        }

        // POST:Sp/Clients/Create
        [HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel client)
        {
			if(ModelState.IsValid){
				var clientDomain = Mapper.Map<ClientViewModel, Client>(client);
				_clientAppService.Add(clientDomain);
				
				return RedirectToAction("Index");
			}
			return View(client);            
        }

        // GET:Sp/Clients/Edit/5
        public ActionResult Edit(int id)
        {
			var clientViewModel = Mapper.Map<Client, ClientViewModel>(_clientAppService.GetById(id));
            return View(clientViewModel);
        }

        // POST:Sp/Clients/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClientViewModel client)
        {
			if (ModelState.IsValid)
			{
				var clientDomain = Mapper.Map<ClientViewModel, Client>(client);
				_clientAppService.Update(clientDomain);				
				return RedirectToAction("Index");
			}
			return View(client);
		}

        // GET:Sp/Clients/Delete/5
        public ActionResult Delete(int id)
        {
			var clientViewModel = Mapper.Map<Client, ClientViewModel>(_clientAppService.GetById(id));
			return View(clientViewModel);
		}

        // POST:Sp/Clients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ClientViewModel client)
        {
			var clientDomain = _clientAppService.GetById(id);
			_clientAppService.Remove(clientDomain);
			return RedirectToAction("Index");
		}
		
		public ActionResult GetPhones(int? id)
		{
			if(id != null)
				return PartialView("Editors/_PhonesEditor", new PhoneViewModel() { ClientId= (int)id });
			else
				return PartialView("Editors/_PhonesEditor", new PhoneViewModel());
		}
	}
}
