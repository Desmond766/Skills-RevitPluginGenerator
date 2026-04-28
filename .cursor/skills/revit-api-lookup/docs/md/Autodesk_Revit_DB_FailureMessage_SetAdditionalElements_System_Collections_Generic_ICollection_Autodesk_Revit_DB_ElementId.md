---
kind: method
id: M:Autodesk.Revit.DB.FailureMessage.SetAdditionalElements(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/cb16cc40-a15b-c6fd-7d53-d897fbe82a9b.htm
---
# Autodesk.Revit.DB.FailureMessage.SetAdditionalElements Method

Sets the additional reference elements for the failure.

## Syntax (C#)
```csharp
public FailureMessage SetAdditionalElements(
	ICollection<ElementId> additionalElements
)
```

## Parameters
- **additionalElements** (`System.Collections.Generic.ICollection < ElementId >`) - The additional elements.

## Returns
The FailureMessage.

## Remarks
Additional elements are used to highlight additional information to the user. They are not
 considered as causing the failure, but are related to it. User cannot delete them in extended error dialog.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessage is already posted to a document

