﻿using System;

namespace TimezonesMVC.Models
{
    public class TimezoneResponseModelPagination
    {
        public int currentPage { get; set; }
        public int totalPages { get; set; }
        public int pageSize { get; set; }
        public int totalRecords { get; set; }
        public List<TimezoneResponseModel> content { get; set; }
    }
}
