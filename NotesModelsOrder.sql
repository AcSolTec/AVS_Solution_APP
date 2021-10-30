

--Save first tb_customersAVS --> tb_formularies

--Cuando se registra un cliente se debe crear el cliente en la BD y en conjunto el formulario
--una vez guardado pasamos a los siguientes modelos segun su orden.

--> tb_personalData
-->	tb_passportDetails

-->	tb_conctactDetails 
--			if have soponsor should be		--> tb_sponsors

--> tb_family_details
--			if have children  should be		--> tb_childrens_familiy
--			if have accompanying should be	--> tb_acompanying_family
--			if have account bank should be	--> tb_bank_family

--> tb_travel_history
--			if visited this country(pakistan) the last 5 years  should be		--> active bit BitVisPakistan
--			if visited other countries the last 2 years  should be				--> active bit BitVisCountries
--			if customer is a deported should be --> tb_deported_travel
--			if customer have criminal charges should be							--> tb_convictions_travel



--Validar el regreso del store procedure o un regreso de info seguro en api
--crear los modelos de arribe en orden
--mapear los objetos