using InvoiceSystem.DAL.Repositories;
using System;

namespace InvoiceSystem.DAL
{
    public class UnitOfWork : IDisposable
    {
        private InvoiceSystemContext context = new InvoiceSystemContext();
        private CustomerRepository _customerRepo;
        private DetailLineRepository _detailLineRepo;
        private InvoiceRepository _invoiceRepo;
        private CityRepository _cityRepo;

        public CustomerRepository CustomerRepo
        {
            get
            {

                if (this._customerRepo == null)
                {
                    this._customerRepo = new CustomerRepository(context);
                }
                return _customerRepo;
            }
        }

        public DetailLineRepository DetailLineRepo
        {
            get
            {

                if (this._detailLineRepo == null)
                {
                    this._detailLineRepo = new DetailLineRepository(context);
                }
                return _detailLineRepo;
            }
        }

        public InvoiceRepository InvoiceRepo
        {
            get
            {

                if (this._invoiceRepo == null)
                {
                    this._invoiceRepo = new InvoiceRepository(context);
                }
                return _invoiceRepo;
            }
        }

        public CityRepository CityRepo
        {
            get
            {

                if (this._cityRepo == null)
                {
                    this._cityRepo = new CityRepository(context);
                }
                return _cityRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
