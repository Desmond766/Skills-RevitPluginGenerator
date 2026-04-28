---
kind: type
id: T:Autodesk.Revit.DB.DisplacementElement
source: html/08113547-eaaa-5ec1-5ff1-de609fe7c29c.htm
---
# Autodesk.Revit.DB.DisplacementElement

A view-specific element that causes other elements to appear to be displaced from their
 actual locations.

## Syntax (C#)
```csharp
public class DisplacementElement : Element
```

## Remarks
The DisplacementElement does not actually change the location of any model
 elements; it merely causes them to be displayed in a different location. An element may only be displaced by a single DisplacementElement in any view. Assigning an
 element to more than one DisplacementElement is an error condition. A DisplacementElement can declare another DisplacementElement as its parent. In that case, its
 transform will be concatenated with that of the parent, and the displacement of its associated
 elements will be relative to the parent DisplacementElement.

