using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSupply.Models {
    public class User {
        public int? AccountID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        private string unsafe_Password;
        public string safe_Password;
        public string Password {
            get { return safe_Password ?? String.Empty; }
            set {
                unsafe_Password = value;
                safe_Password = new String('*', value.Length);
            }
        }
        public bool LoggedIn() {
            return AccountID.HasValue; //can reasonably assume AccountID should only be set when user is found in DB (and has logged in).
        }
        public override string ToString() {
            return $"AccID: {AccountID ?? 0}, User: {Username ?? "No User"}, Email: {Email ?? "No Email"}, Pass: {Password}";
        }
    }
}
