---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricArea.TagViewId
source: html/8ab10b80-d3ee-199f-b87d-8356a85d0109.htm
---
# Autodesk.Revit.DB.Structure.FabricArea.TagViewId Property

The element of the view in which to tag new members of this element.

## Syntax (C#)
```csharp
public ElementId TagViewId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: tagViewId is not a valid view for tagging the FabricArea or FabricSheets.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

