---
kind: property
id: P:Autodesk.Revit.DB.Element.CreatedPhaseId
zh: 构件、图元、元素
source: html/c6032e01-f7cb-b2ea-3312-697d14216a31.htm
---
# Autodesk.Revit.DB.Element.CreatedPhaseId Property

**中文**: 构件、图元、元素

Id of a Phase at which the Element was created.

## Syntax (C#)
```csharp
public ElementId CreatedPhaseId { get; set; }
```

## Remarks
After setting the property CreatedPhaseId, regeneration can fail if CreatedPhaseId and DemolishedPhaseId
 are out of order with respect to their index in the property Document.Phases . When Revit is running with UI activated, the default created phase for newly created elements is inherited from the phase of the currently active view. When Revit is running without its UI, such as when Revit runs on Autodesk Forge Design Automation API for Revit,
 the default CreatedPhaseId for newly created elements is the latest phase in Autodesk::Revit::DB::Document::Phases .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The element does not allow setting the property CreatedPhaseId to the value of createdPhaseId.
 -or-
 When setting this property: Invalid order of phases: An object cannot be demolished before it was created.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The element does not have properties CreatedPhaseId and DemolishedPhaseId.
 -or-
 When setting this property: The element does not allow setting the properties CreatedPhaseId and DemolishedPhaseId.

