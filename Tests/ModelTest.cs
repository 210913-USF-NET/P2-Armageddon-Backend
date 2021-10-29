using Models;
using System;
using Xunit;

namespace Tests
{
    public class ModelTest
    {
        
        [Fact]
        public void FriendsIdShouldBeValid()
        {
            //Arrange
            Friends friend = new Friends();
            int id = 1;

            //Act
            friend.Id = id;

            //Assert
            Assert.Equal(id, friend.Id);
        }

        [Fact]
        public void ChatHistoryMessageShouldBeValid()
        {
            ChatHistory chat = new ChatHistory();
            string message = "My message";

            //Act
            chat.Message = message;

            Assert.Equal(message, chat.Message);
        }

        [Fact]
        public void UserShouldBeInstantiated()
        {

            User user = new User();
            user.Username = "Tenzin";
            user.Email = "1@gmail.com";

            Assert.NotNull(user);
        }

        [Fact]
        public void MatchShouldBeInstantiated()
        {
            Match match = new Match();

            Assert.NotNull(match);
        }

        [Fact]
        public void LayoutShouldBeInstantiated()
        {
            Layout layout = new Layout();

            Assert.NotNull(layout);
        }

        [Fact]
        public void FriendsShouldBeInstantiated()
        {
            Friends friend = new Friends();
            Assert.NotNull(friend);
        }

    }

}
