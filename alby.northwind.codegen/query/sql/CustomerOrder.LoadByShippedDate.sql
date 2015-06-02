where c.customerid = o.customerid
and coalesce( o.shippeddate, '1900-01-01' ) = coalesce( @shippeddate, '1900-01-01' )

