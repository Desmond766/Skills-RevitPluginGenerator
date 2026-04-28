---
kind: method
id: M:Autodesk.Revit.DB.ElementId.TryParse(System.String,Autodesk.Revit.DB.ElementId@)
source: html/7b254b04-e251-ea50-3678-4b530009c1b0.htm
---
# Autodesk.Revit.DB.ElementId.TryParse Method

Parse the string representation of the id into a corresponding ElementId.

## Syntax (C#)
```csharp
public static bool TryParse(
	string idStr,
	out ElementId id
)
```

## Parameters
- **idStr** (`System.String`) - The string representation of the id to return.
- **id** (`Autodesk.Revit.DB.ElementId %`) - Out parameter set to the ElementId represented by the string.

## Returns
true if the string was successfully parsed into an ElementId, false otherwise.

## Remarks
If the string represents [!:Autodesk::Revit::DB::Element::InvalidElementId] the id
will contain it upon return. If the parse fails, the id will be undefined.

