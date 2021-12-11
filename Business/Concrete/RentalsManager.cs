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

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalsDal.Add(rental);
                return new SuccessResult(Messages.RentalsAdded);
            }
            else
            {
                return new SuccessResult(Messages.RentalsInvalid);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalsDal.Delete(rental);
            return new SuccessResult(Messages.RentalsDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(),Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int rentalsId)
        {
            return new SuccessDataResult<Rental>(_rentalsDal.Get(r => r.RentalId == rentalsId));
        }

        public IResult Update(Rental rental)
        {
            return new SuccessResult(Messages.RentalsUpdated);
        }
    }
}
