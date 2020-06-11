using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceForWorkingWithApartmentBuilding.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Не указана Дата Рождения")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Не указан id дома")]
        public Guid HouseId { get; set; }

        [Required(ErrorMessage = "Не указан номер подьезда")]
        public int EntranceNumber { get; set; }

        [Required(ErrorMessage = "Не указан номер квартиры")]
        public int FlatNumber { get; set; }
    }
}
