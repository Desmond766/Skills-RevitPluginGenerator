---
kind: type
id: T:Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException
source: html/c5b911f6-1e8f-2cd4-6965-286f41221fe0.htm
---
# Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException

The exception that is thrown when making or attempting to make changes that are forbidden during dynamic updates to the model.

## Syntax (C#)
```csharp
[SerializableAttribute]
public class ForbiddenForDynamicUpdateException : InvalidOperationException
```

## Remarks
Modifications leading to a new mutual relationship between
elements that did not depend on each other before are potentially 
not safe in work-set environment. This exception is thrown when 
an Updater either makes such modifications or attempts to call 
a method that will or may modify the model in such unsafe matter.

