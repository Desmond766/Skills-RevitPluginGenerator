---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.FlexPipe.IsFlexPipeTypeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/5078748d-39a2-f720-0982-8b550cc43361.htm
---
# Autodesk.Revit.DB.Plumbing.FlexPipe.IsFlexPipeTypeId Method

Checks if given type is valid flexible pipe type.

## Syntax (C#)
```csharp
public static bool IsFlexPipeTypeId(
	Document document,
	ElementId pipeTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **pipeTypeId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the flexible pipe type to check.

## Returns
True if flexible pipe type can used for this pipe, false otherwise.

## Remarks
A type is valid for flexible pipe if it can be used to the flexible pipe element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

