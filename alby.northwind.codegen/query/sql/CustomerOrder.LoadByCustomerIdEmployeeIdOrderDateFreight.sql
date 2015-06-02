where c.customerid = o.customerid
and c.customerid = @customerid
and o.employeeid = @employeeid
and o.orderdate = @orderdate
and o.freight = @freight
order by c.companyname, o.orderdate
