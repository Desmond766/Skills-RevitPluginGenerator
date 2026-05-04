---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetAllFabricationConnectorDefinitions(Autodesk.Revit.DB.ConnectorDomainType,Autodesk.Revit.DB.ConnectorProfileType)
source: html/d694f14a-7afc-1f01-334a-94dd21985835.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetAllFabricationConnectorDefinitions Method

Gets fabrication connector identifiers from the fabrication configuration, filtered by shape and domain.

## Syntax (C#)
```csharp
public IList<int> GetAllFabricationConnectorDefinitions(
	ConnectorDomainType domain,
	ConnectorProfileType shape
)
```

## Parameters
- **domain** (`Autodesk.Revit.DB.ConnectorDomainType`) - ConnectorDomainType to filter by. Pass ConnectorDomainType.Undefined to get all connector domains.
- **shape** (`Autodesk.Revit.DB.ConnectorProfileType`) - ConnectorProfileType to filter by. Pass ConnectorProfileType.Invalid to get all shapes.

## Returns
All the fabrication connector identifiers, filtered by shape and domain. The return will be empty if no connectors are found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

