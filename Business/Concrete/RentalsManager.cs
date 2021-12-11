using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalsDal;
        public RentalsManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        public IResult Add(Rentals rentals)
        {
            if (rentals.ReturnDate != null)
            {
                _rentalsDal.Add(rentals);
                return new SuccessResult(Messages.RentalsAdded);
            }
            else
            {
                return new SuccessResult(Messages.RentalsInvalid);
            }
        }

        public IResult Delete(Rentals rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(Messages.RentalsDeleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll(),Messages.RentalsListed);
        }

        public IDataResult<Rentals> GetById(int rentalsId)
        {
            return new SuccessDataResult<Rentals>(_rentalsDal.Get(r => r.RentalId == rentalsId));
        }

        public IResult Update(Rentals rentals)
        {
            return new SuccessResult(Messages.RentalsUpdated);
        }
    }
}
