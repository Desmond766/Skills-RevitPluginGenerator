---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.GetTopLevelLink(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalResourceReference)
source: html/9a32ed88-9ac4-68eb-a129-69cf29aa496d.htm
---
# Autodesk.Revit.DB.RevitLinkType.GetTopLevelLink Method

Returns the ElementId of the (top-level) linked model with the given
 ExternalResourceReference.

## Syntax (C#)
```csharp
public static ElementId GetTopLevelLink(
	Document document,
	ExternalResourceReference reference
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to look for the linked model in.
- **reference** (`Autodesk.Revit.DB.ExternalResourceReference`) - An ExternalResourceReference indicating which linked model to return.

## Returns
The id of the link with the given ExternalResourceReference,
 or InvalidElementId if
 there is no top-level link at that location.

## Remarks
This function will not return nested links. Revit will not check the version when checking for
 resource equality.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

