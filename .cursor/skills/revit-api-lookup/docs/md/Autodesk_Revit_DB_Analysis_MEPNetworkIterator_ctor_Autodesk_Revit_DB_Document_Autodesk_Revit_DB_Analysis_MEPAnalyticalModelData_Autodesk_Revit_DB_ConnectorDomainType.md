---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MEPNetworkIterator.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData,Autodesk.Revit.DB.ConnectorDomainType)
source: html/c8c0e997-f48a-1f91-0a5d-98406dafa82c.htm
---
# Autodesk.Revit.DB.Analysis.MEPNetworkIterator.#ctor Method

Creates an iterator by the analytical model data to visit all connected components in the network.

## Syntax (C#)
```csharp
public MEPNetworkIterator(
	Document pADoc,
	MEPAnalyticalModelData seed,
	ConnectorDomainType eDomain
)
```

## Parameters
- **pADoc** (`Autodesk.Revit.DB.Document`) - The document of the analytical network.
- **seed** (`Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData`) - The analytical model data of the starting element.
- **eDomain** (`Autodesk.Revit.DB.ConnectorDomainType`) - The domain of network that the iteration happens.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

