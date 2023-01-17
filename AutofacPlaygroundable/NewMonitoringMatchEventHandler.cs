﻿using AutofacPlaygroundable.DomainEvents;

namespace AutofacPlaygroundable;

public sealed class NewMonitoringMatchEventHandler : DomainEventHandler<NewMonitoringMatchEvent>
{
    protected override async Task HandleAsync(NewMonitoringMatchEvent domainEvent, CancellationToken cancellationToken)
    {
        var notificationText = CreateMonitoringListMatchMessage(domainEvent.Match);

        Console.WriteLine(notificationText);
                        
    }

    private static string CreateMonitoringListMatchMessage(long match)
    {

        var message = "СОВПАДЕНИЕ ПО ЧЕРНЫМ СПИСКАМ\n\n" +
                      $"ФИО: {match}\n" +
                      $"Совпадение с {match}\n" +
                      $"Дата: \n";
        return message;
    }
}