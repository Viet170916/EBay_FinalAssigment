﻿using API.BU.Services.Interfaces;
using API.Data.Repositories.Interfaces;

namespace API.BU.Services.Implementations;

public class AddressService(IAddressRepository addressRepository) : IAddressService { }
