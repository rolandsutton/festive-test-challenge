## Day 5

After a night on the Egg Nog the Dev Ops elves have decided that maybe after all
there was some room for improvement on the driver validator, and they now have a TryIsValid
method that will indicate success and potentially return more information about the driver.
There is no concrete implementation of IDriverInfo so for now you'll just have to mock the interface.

# Hint

This is thinking about what NSubstitute or any mocking framework can do for you rather
than the need to roll your own.