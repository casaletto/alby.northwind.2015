where c.customerid = o.customerid
and isnull(c.region, '') = isnull(@region, '')

