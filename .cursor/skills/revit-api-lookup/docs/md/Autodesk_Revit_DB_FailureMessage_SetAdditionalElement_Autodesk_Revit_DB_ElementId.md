---
kind: method
id: M:Autodesk.Revit.DB.FailureMessage.SetAdditionalElement(Autodesk.Revit.DB.ElementId)
source: html/b823f3e9-5d3f-f92f-3f52-12c1f48d023a.htm
---
# Autodesk.Revit.DB.FailureMessage.SetAdditionalElement Method

Sets the additional reference element for the failure.

## Syntax (C#)
```csharp
public FailureMessage SetAdditionalElement(
	ElementId additionalElement
)
```

## Parameters
- **additionalElement** (`Autodesk.Revit.DB.ElementId`) - The additional element.

## Returns
The FailureMessage.

## Remarks
Additional elements are used to highlight additional information to the user. They are not
 considered as causing the failure, but are related to it. User cannot delete them in extended error dialog.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessage is already posted to a document

