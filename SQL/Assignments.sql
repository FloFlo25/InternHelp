--Assignments - SELECT - WHERE
--Ex.1
select 
	FullName, PhoneNumber, EmailAddress
from
	[WideWorldImporters].[Application].[People]

--Ex.2
select 
	CountryName,
	Continent
from
	[WideWorldImporters].[Application].[Countries]
where 
	Continent='Europe'


--Ex.3
select 
	*
from
	[WideWorldImporters].[Sales].[OrderLines]
where
	Quantity>=100


--Ex.4
select 
	*
from
	[WideWorldImporters].[Application].[PaymentMethods]
where
	PaymentMethodName <> 'Check'


--Assignments - SELECT - LIKE, BETWEEN, IN
--Ex.1

select 
	*
from
	[WideWorldImporters].[Application].[People]
where
	FullName like 'a%'

--Ex.2
select
	*
from
	[WideWorldImporters].[Sales].[Orders]
where
	OrderDate > '2016-01-01'


--Ex.3
select
	*
from
	[WideWorldImporters].[Sales].[Invoices]
where
	TotalDryItems=1 or TotalDryItems=3

--Ex.4
select 
	*
from
	[WideWorldImporters].[Application].[Cities]
where
	CityName like '__a%'

--Assignments - SELECT - NULL, OR, AND, TOP, AS
--Ex.1
select 
	*
from
	[WideWorldImporters].[Application].[Cities]
where
	LatestRecordedPopulation is not null

--Ex.2
select 
	CountryName as Country, 
	IsoNumericCode as IsoCode,
	LatestRecordedPopulation as [Population]
from
	[WideWorldImporters].[Application].[Countries]

--Ex.3
select 
	* 
from 
	[WideWorldImporters].[Application].[People]
where
	IsEmployee=1 and IsSalesperson=1

--Ex.4
select
	*
from
	[WideWorldImporters].[Sales].[OrderLines]
where
	Quantity < 50 or UnitPrice < 20

--Ex.5
select top 10
	*
from 
	[WideWorldImporters].[Application].[Countries]
where
	CountryName like 'c%'


--Assignments - SELECT - ORDER BY, Aggregations
--Ex.1
select 
	*
from
	[WideWorldImporters].[Sales].[OrderLines]
order by
	Quantity

--Ex.2
select
	*
from
	[WideWorldImporters].[Sales].[Orders]
order by 
	ExpectedDeliveryDate desc

--Ex.3
select
	avg(TaxAmount) as [Average tax amount]
from
	[WideWorldImporters].[Purchasing].[SupplierTransactions]
where
	TaxAmount>0

--Ex.4
select
	sum(TransactionAmount) as [Total amount of the translation amount]
from
	[WideWorldImporters].[Purchasing].[SupplierTransactions]
where
	SupplierInvoiceNumber is not null


--Assignments - SELECT - GROUP BY, HAVING, CASE
--Ex.1
select
	COUNT(InvoiceID) as [Invoices],
	TotalDryItems
from
	[WideWorldImporters].[Sales].[Invoices]
group by
	TotalDryItems
order by
	TotalDryItems

	select * from [WideWorldImporters].[Sales].[Invoices]


--Ex.2
select
	BinLocation,
	sum(LastCostPrice) as [Total cost price]
from
	[WideWorldImporters].[Warehouse].[StockItemHoldings]
group by
	BinLocation
order by
	BinLocation
--Ex.3
select	
	count(PurchaseOrderID) as [Total amount of orders],
	DeliveryMethodID 
from 
	[WideWorldImporters].[Purchasing].[PurchaseOrders]
group by
	DeliveryMethodID
having
	count(PurchaseOrderID)>500

--Ex.4
select
	PackageTypeID,
	sum(ExpectedUnitPricePerOuter) as [Total expected unit price]
from
	[WideWorldImporters].[Purchasing].[PurchaseOrderLines]
group by
	PackageTypeId
having
	sum(ExpectedUnitPricePerOuter) <= 1000

--Ex.5
select 
	*,
	case
		when LatestRecordedPopulation<50000 or LatestRecordedPopulation is null then '<50000'
		when LatestRecordedPopulation between 50000 and 100000 then '50000-100000'
		else '>100000'
	end as [Population size category]
from 
	[WideWorldImporters].[Application].[Cities]


--Assignments - Joins
--Ex.1
select 
	O.*,
	OL.*
from
	[WideWorldImporters].[Sales].[Orders] as O
left join 
	[WideWorldImporters].[Sales].[OrderLines] as OL
on 
	O.OrderID=OL.OrderID
where
	OL.Quantity >250

--Ex.2 versiunea cu null
select 
	P.FullName,
	O.*
from
	[WideWorldImporters].[Sales].[Orders] as O
left join 
	[WideWorldImporters].[Application].[People] as P
on
	O.PickedByPersonID=P.PersonID

--Ex.2 versiunea fara null
select 
	P.FullName,
	O.*
from
	[WideWorldImporters].[Sales].[Orders] as O
left join 
	[WideWorldImporters].[Application].[People] as P
on
	O.PickedByPersonID=P.PersonID
where
	P.FullName is not null

--Ex.3
select 
	I.OrderID,
	O.OrderID,
	I.DeliveryMethodID,
	D.DeliveryMethodID
from
	[WideWorldImporters].[Sales].[Orders] as O
left outer join 
	[WideWorldImporters].[Sales].[Invoices] as I
on
	O.OrderID=I.OrderID
left outer join
	[WideWorldImporters].[Application].[DeliveryMethods] as D
on
	I.DeliveryMethodID=D.DeliveryMethodID
where
	D.DeliveryMethodName='Courier'

--Ex.4
select 
* 
from 
	[WideWorldImporters].[Purchasing].[PurchaseOrders] as PO
JOIN 
	[WideWorldImporters].[Purchasing].[PurchaseOrderLines] as POL 
on 
	PO.PurchaseOrderID = POL.PurchaseOrderID
JOIN 
	[WideWorldImporters].[Purchasing].[Suppliers] as S 
on 
	S.SupplierID = PO.SupplierID
join
	[WideWorldImporters].[Warehouse].[PackageTypes] as PT
on
	PT.LastEditedBy=PO.LastEditedBy and Pt.PackageTypeName='Pallet'