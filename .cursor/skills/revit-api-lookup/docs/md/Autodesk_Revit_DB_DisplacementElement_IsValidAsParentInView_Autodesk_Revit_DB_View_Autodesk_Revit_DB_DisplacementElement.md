---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.IsValidAsParentInView(Autodesk.Revit.DB.View,Autodesk.Revit.DB.DisplacementElement)
source: html/d9da79d4-c559-96ec-a4cf-c2778221121c.htm
---
# Autodesk.Revit.DB.DisplacementElement.IsValidAsParentInView Method

Indicates whether the specified DisplacementElement can be used as a parent when
 creating a DisplacementElement in the specified view.

## Syntax (C#)
```csharp
public static bool IsValidAsParentInView(
	View view,
	DisplacementElement parent
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - A view.
- **parent** (`Autodesk.Revit.DB.DisplacementElement`) - A DisplacementElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

