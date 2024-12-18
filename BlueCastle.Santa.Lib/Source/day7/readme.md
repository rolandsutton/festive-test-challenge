

# Day 7

Continued breaking of the sledge driving rules by certain Elves (who shall remain un-named) has 
led to the realisation that the sledges should publish their position every 10seconds.
Write tests to verify that the sledge broadcasts position. There are two version of the Sledge V1 and V2
both can be tested but when testing v2 the FakeTimeProvider in Microsoft.Extensions.TimeProvider.Testing
Nuget package will allow you to Skip/Teleport (Teleport sounds so much cooler 🙂 ) so the test doesn't need
to sleep for the timer to elapse.