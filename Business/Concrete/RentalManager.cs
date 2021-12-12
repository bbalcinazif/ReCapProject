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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalsDal;
        public RentalManager(IRentalDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        public IResult Add(Rental rentals)
        {
            if (rentals.ReturnDate != null)
            {
                _rentalsDal.Add(rentals);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                return new SuccessResult(Messages.RentalInvalid);
            }
        }

        public IResult Delete(Rental rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalsId)
        {
            return new SuccessDataResult<Rental>(_rentalsDal.Get(r => r.RentalId == rentalsId));
        }

        public IResult Update(Rental rentals)
        {
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
