using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Models
{
    public class RequestModel
    {
        [Key]
        public int id_transaksi { get; set; }
        public int id_user { get; set; }
        public string nama_barang { get; set; }
        public string spesifikasi { get; set; }
        public int jumlah { get; set; }

    }
}
