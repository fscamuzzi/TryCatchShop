using DTO.Dto;

namespace DTO.Constant
{
    public static class Constant
    {
        public static class TRYCATCHSHOP
        {
         
        }

        public static class Form
        {
            public static readonly string FormEncoded = "application/x-www-form-urlencoded";
        }

        public static class RoleConstant
        {
            private static RoleDTO _admin = new RoleDTO
            {
                Id = "1",
                Name = "Admin"
            };

            private static RoleDTO _customer = new RoleDTO
            {
                Id = "2",
                Name = "Customer"
            };

            public static RoleDTO Admin
            {
                get { return _admin; }
                set { _admin = value; }
            }

            public static RoleDTO Customer
            {
                get { return _customer; }
                set { _customer = value; }
            }
        }
    }
}
