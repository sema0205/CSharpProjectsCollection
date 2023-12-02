using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.ConsoleWriter;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Results;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class TestCases
{
    [Fact]
    public void SendMessageDefaultStatusShouldBeTreatedAsUnRead()
    {
        var user = new User();

        IRecipient recipientUser = new RecipientUser(user);
        IRecipient recipientProxy = new RecipientImportantLevelProxy(recipientUser, 5);

        ITopic topic = new Topic(recipientProxy, "TopicName");
        var message = new Message("Title", "Body", 2);

        topic.SendMessage(message);
        Assert.False(user.MessagesStatuses.First().Status);
    }

    [Fact]
    public void ReadMessageWithUnReadStatusShouldBeChangedToReadStatus()
    {
        var user = new User();

        IRecipient recipientUser = new RecipientUser(user);
        IRecipient recipientProxy = new RecipientImportantLevelProxy(recipientUser, 5);

        ITopic topic = new Topic(recipientProxy, "TopicName");
        var message = new Message("Title", "Body", 2);

        topic.SendMessage(message);
        Assert.False(user.MessagesStatuses.First().Status);

        UserReadMessageResult readMessageResult = user.ReadMessage(message);
        Assert.Equal(new UserReadMessageResult.Success(), readMessageResult);
        Assert.True(user.MessagesStatuses.First().Status);
    }

    [Fact]
    public void ReadMessageWithReadStatusShouldReturnError()
    {
        var user = new User();

        IRecipient recipientUser = new RecipientUser(user);
        IRecipient recipientProxy = new RecipientImportantLevelProxy(recipientUser, 5);

        ITopic topic = new Topic(recipientProxy, "TopicName");
        var message = new Message("Title", "Body", 2);

        topic.SendMessage(message);
        Assert.False(user.MessagesStatuses.First().Status);

        UserReadMessageResult readMessageResult = user.ReadMessage(message);
        Assert.Equal(new UserReadMessageResult.Success(), readMessageResult);
        Assert.True(user.MessagesStatuses.First().Status);

        UserReadMessageResult readMessageSecondTryResult = user.ReadMessage(message);
        Assert.Equal(new UserReadMessageResult.MessageWasAlreadyRead(), readMessageSecondTryResult);
    }

    [Fact]
    public void SendMessageWithNoSuitableLevelOfImportanceShouldNotReachTheRecipient()
    {
        ILogger userLoggerMock = Substitute.For<ILogger>();
        var user = new User();

        IRecipient recipientUser = new RecipientUser(user);
        IRecipient recipientLogger = new RecipientLogger(userLoggerMock, recipientUser);
        IRecipient recipientProxy = new RecipientImportantLevelProxy(recipientLogger, 4);

        ITopic topic = new Topic(recipientProxy, "TopicName");
        var message = new Message("Title", "Body", 6);

        topic.SendMessage(message);

        userLoggerMock.DidNotReceive().LogMessage(message);
    }

    [Fact]
    public void LogMessageWithSetupLoggerShouldDoLoggingOnMessageRecieving()
    {
        ILogger userLoggerMock = Substitute.For<ILogger>();
        var user = new User();

        IRecipient recipientUser = new RecipientUser(user);
        IRecipient recipientLogger = new RecipientLogger(userLoggerMock, recipientUser);
        IRecipient recipientProxy = new RecipientImportantLevelProxy(recipientLogger, 5);

        ITopic topic = new Topic(recipientProxy, "TopicName");
        var message = new Message("Title", "Body", 2);

        topic.SendMessage(message);

        userLoggerMock.Received().LogMessage(message);
    }

    [Fact]
    public void SendMessageWithMessengerAsReceiverShouldProduceExpectedValue()
    {
        IConsoleWriter messengerWriterMock = Substitute.For<IConsoleWriter>();
        var messenger = new Messenger(messengerWriterMock);

        IRecipient recipientMessenger = new RecipientMessenger(messenger);
        IRecipient recipientProxy = new RecipientImportantLevelProxy(recipientMessenger, 3);

        ITopic topic = new Topic(recipientProxy, "TopicName");
        var message = new Message("Title", "Body", 2);
        topic.SendMessage(message);

        messengerWriterMock.Received().Write(message.Title);
        messengerWriterMock.Received().Write(message.Body);
    }
}