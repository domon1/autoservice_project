using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.Entityes;

namespace BusinessLayer
{
    public class DataManager
    {
        private ICarRepository _carRepository;
        private ICarServiceRepository _carServiceRepository;
        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;
        private ISparepartRepository _sparepartRepository;
        private IStaffRepository _staffRepository;
        private ITimeOrderRepository _timeOrderRepository;

        public DataManager(
            ICarRepository carRepository,
            ICarServiceRepository carServiceRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            ISparepartRepository sparepartRepository,
            IStaffRepository staffRepository,
            ITimeOrderRepository timeOrderRepository
            )
        {
            _carRepository = carRepository;
            _carServiceRepository = carServiceRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _sparepartRepository = sparepartRepository;
            _staffRepository = staffRepository;
            _timeOrderRepository = timeOrderRepository;
    }

        public ICarRepository Cars { get { return _carRepository; } }
        public ICarServiceRepository CarService { get { return _carServiceRepository; } }
        public ICustomerRepository Customer { get { return _customerRepository; } }
        public IOrderRepository Order { get { return _orderRepository; } }
        public ISparepartRepository Sparepart { get { return _sparepartRepository; } }
        public IStaffRepository Staff { get { return _staffRepository; } }
        public ITimeOrderRepository TimeOrder { get { return _timeOrderRepository; } }
    }
}
