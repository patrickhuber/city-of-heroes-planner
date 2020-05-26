resource "azurerm_dns_zone" "cityofinfo" {
  name                = ".cityof.info"
  resource_group_name = azurerm_resource_group.cityofinfo.name
}
