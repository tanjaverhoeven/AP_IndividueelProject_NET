﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvoiceSystem.BLL;
using InvoiceSystem.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InvoiceSystem.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private RoleBusinessLogic _roleLogic;
        private ApplicationDbContext _dbContext;

        public RoleController()
        {
            _dbContext = new ApplicationDbContext();
            _roleLogic = new RoleBusinessLogic(new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext)));
        }

        public ActionResult Index()
        {
            return View(_roleLogic.All());
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole identityRole)
        {
            try
            {
                // TODO: Add insert logic here
                _roleLogic.Insert(identityRole);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            IdentityRole identityRole = _roleLogic.FindById(id);
            if (identityRole == null)
            {
                return HttpNotFound();
            }
            return View(identityRole);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(IdentityRole identityRole)
        {
            try
            {
                // TODO: Add update logic here
                _roleLogic.Update(identityRole);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole identityRole = _roleLogic.FindById(id);
            if (identityRole == null)
            {
                return HttpNotFound();
            }
            return View(identityRole);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            _roleLogic.Delete(_roleLogic.FindById(id));
            return RedirectToAction("Index");

        }
    }
}