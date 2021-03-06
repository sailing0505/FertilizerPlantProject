﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.entities.distributors;

namespace UserManagementService.services.distributors
{
    public interface DistributorService
    {
        void Add(DistributorModel model);
        IList<string> GetAllDistributorNames();
        void BulkSave(IList<DistributorModel> distributors);
        DistributorModel FindById(string id);
    }
}
