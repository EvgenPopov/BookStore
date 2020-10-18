using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BooStore.Tests
{
    public class CartTests
    {

        [Fact]
        public void Can_Add_New_Orders()
        {
            Book book1 = new Book { BookId = 1, Name = "B1" };
            Book book2 = new Book { BookId = 2, Name = "B2" };

            Cart cart = new Cart();

            cart.AddOrder(book1, 1);
            cart.AddOrder(book2, 1);

            Order[] orders = cart.Orders.ToArray();

            Assert.Equal(book1.Name, orders[0].Book.Name);
            Assert.Equal(book2.Name, orders[1].Book.Name);
            Assert.Equal(2, orders.Length);
        }


        
        [Fact]
        public void Can_Add_Quanity_For_Existing_Order()
        {
            Book book1 = new Book { BookId = 1, Name = "B1" };

            Cart cart = new Cart();

            cart.AddOrder(book1, 1);
            cart.AddOrder(book1, 3);

            Order[] orders = cart.Orders.ToArray();

            Assert.Equal(1, orders.Length);

            Assert.Equal(4, orders[0].Quanity);

        }

    }
}
