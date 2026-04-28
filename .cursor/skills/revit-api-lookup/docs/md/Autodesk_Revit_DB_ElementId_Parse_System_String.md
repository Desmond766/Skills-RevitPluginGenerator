---
kind: method
id: M:Autodesk.Revit.DB.ElementId.Parse(System.String)
source: html/aa22f1f3-4e78-ebd0-705f-084dd1a54eac.htm
---
# Autodesk.Revit.DB.ElementId.Parse Method

Parse the string representation of the id into a corresponding ElementId.

## Syntax (C#)
```csharp
public static ElementId Parse(
	string idStr
)
```

## Parameters
- **idStr** (`System.String`) - The string representation of the id to return.

## Returns
ElementId string represented.

## Remarks
If the string represents [!:Autodesk::Revit::DB::Element::InvalidElementId] it will be returned.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the string cannot be parsed into an ElementId.

