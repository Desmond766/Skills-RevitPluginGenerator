---
kind: property
id: P:Autodesk.Revit.DB.Element.DemolishedPhaseId
zh: 构件、图元、元素
source: html/7949a983-c5dc-62a3-594a-d685365449d5.htm
---
# Autodesk.Revit.DB.Element.DemolishedPhaseId Property

**中文**: 构件、图元、元素

Id of a Phase at which the Element was demolished.

## Syntax (C#)
```csharp
public ElementId DemolishedPhaseId { get; set; }
```

## Remarks
After setting the property, DemolishedPhaseId regeneration can fail if CreatedPhaseId and DemolishedPhaseId
 are out of order with respect to their index in the property Document.Phases .
 Can be set to invalid element id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The element does not allow setting the property DemolishedPhaseId to the value of demolishedPhaseId.
 -or-
 When setting this property: Invalid order of phases: An object cannot be demolished before it was created.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The element does not have properties CreatedPhaseId and DemolishedPhaseId.
 -or-
 When setting this property: The element does not allow setting the properties CreatedPhaseId and DemolishedPhaseId.

