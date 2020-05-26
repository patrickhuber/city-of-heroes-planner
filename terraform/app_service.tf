resource "azurerm_app_service_plan" "cityofinfo" {
  name                = "example-appserviceplan"
  location            = azurerm_resource_group.cityofinfo.location
  resource_group_name = azurerm_resource_group.cityofinfo.name

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "cityofinfo" {
  name                = "example-app-service"
  location            = azurerm_resource_group.cityofinfo.location
  resource_group_name = azurerm_resource_group.cityofinfo.name
  app_service_plan_id = azurerm_app_service_plan.cityofinfo.id

  site_config {
    dotnet_framework_version = "v4.0"
    scm_type                 = "LocalGit"
  }
}
