---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.CreateFreeForm(Autodesk.Revit.DB.Document,System.Guid,Autodesk.Revit.DB.Structure.RebarBarType,Autodesk.Revit.DB.Element)
zh: 钢筋、配筋
source: html/0528ba3a-2893-cc05-0ee6-67fa3eb087e2.htm
---
# Autodesk.Revit.DB.Structure.Rebar.CreateFreeForm Method

**中文**: 钢筋、配筋

Creates a free form rebar that can have constraints.

## Syntax (C#)
```csharp
public static Rebar CreateFreeForm(
	Document doc,
	Guid serverGUID,
	RebarBarType barType,
	Element host
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A Document.
- **serverGUID** (`System.Guid`) - The API server GUID.
 Should be the same that the function GetServerId() from class derived from IRebarUpdateServer returns.
 This server has the responsibility to calculate the bars of Rebar.
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A RebarBarType element that defines bar diameter, bend radius and material of the rebar.
- **host** (`Autodesk.Revit.DB.Element`) - The element to which the rebar belongs. The element must support rebar hosting.

## Returns
The newly created free form Rebar Instance.

## Remarks
It requires a server GUID which will have the responsibility to define bar handles(which will be constrained) and to do the calculation of the curves.
 See IRebarUpdateServer for more details.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - host is not a valid rebar host.
 -or-
 The server with serverGUID was not registered for RebarUpdateService.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

