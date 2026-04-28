---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.LocateFabricationConnector(System.String,System.String,Autodesk.Revit.DB.ConnectorDomainType,Autodesk.Revit.DB.ConnectorProfileType)
source: html/02a21b64-3880-17fa-6646-05ebe0c759fd.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.LocateFabricationConnector Method

Gets the fabrication connector identifiers by group and name, filtered by shape and domain.

## Syntax (C#)
```csharp
public int LocateFabricationConnector(
	string group,
	string name,
	ConnectorDomainType domain,
	ConnectorProfileType shape
)
```

## Parameters
- **group** (`System.String`) - The fabrication connector group.
- **name** (`System.String`) - The fabrication connector name.
- **domain** (`Autodesk.Revit.DB.ConnectorDomainType`) - ConnectorDomainType to filter by. Pass ConnectorDomainType::Undefined to get all connector domains.
- **shape** (`Autodesk.Revit.DB.ConnectorProfileType`) - ConnectorProfileType to filter by. Pass ConnectorProfileType::Invalid to get all shapes.

## Returns
Return the fabrication connector identifier. Returns -1 if not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

