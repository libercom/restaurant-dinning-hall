# Dinning Hall

The Dinning Hall consists of tables and waiters . You have to design a mechanism which will simulate tables occupation.
At start of simulation, tables should not be totally occupied and you have to take into a count that it takes time for a table to be
occupied after it was vacated.
In the Dinning Hall you should have a collection(array) of tables .
Tables should be a dedicated objects. Each table should have a state of:

-   being free
-   waiting to make a order
-   waiting for a order to be served

Waiters should be an object instances which run their logic of serving tables on separate threads , one thread per waiter .
Waiters should look for tables which was not served, meaning that order was not picked up yet. For Waiters which are
running on separate threads , tables are shared resource. Waiters are looking in the collection of tables for such table
which is ready to make a order. When waiter is picking up the order from a table , it(table) should generate a random order
with random foods and random number of foods, random priority and unique order ID.

Number of tables and waiters should be configurable.

After picking up an order , don't forget that this operation takes some amount of time. Waiter have to send order to
kitchen by performing HTTP (POST) request, with order details.

When order will be ready, kitchen will send a HTTP (POST) request back to Dinning Hall . Your Dinning Hall server has
to handle that request and to notify waiter that order is ready to be served to the table which requested this order.
Your task here is to design a mechanism for serving prepared orders to tables . The order should be served to the table
by the waiter which picked up that specific order. When order is served table should check that served order is the
same order what was requested.
