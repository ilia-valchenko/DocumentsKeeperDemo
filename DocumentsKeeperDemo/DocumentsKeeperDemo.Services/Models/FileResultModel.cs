﻿using System;
using System.Collections.Generic;

namespace DocumentsKeeperDemo.Services.Models
{
    /// <summary>
    /// The file result model.
    /// </summary>
    public class FileResultModel
    {
        public IEnumerable<string> FileNames { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
        public string DownloadLink { get; set; }
        public IEnumerable<string> ContentTypes { get; set; }
        public IEnumerable<string> Names { get; set; }
        public IEnumerable<long?> FileSizes { get; set; }
    }
}