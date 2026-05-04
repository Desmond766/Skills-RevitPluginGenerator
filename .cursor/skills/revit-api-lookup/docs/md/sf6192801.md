---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.PromptToMatchElementType(Autodesk.Revit.DB.ElementType)
source: html/48e7741b-970c-8ee7-5987-914ca6e2f321.htm
---
# Autodesk.Revit.UI.UIDocument.PromptToMatchElementType Method

Prompts the user to select elements to change them to the input type.

## Syntax (C#)
```csharp
public void PromptToMatchElementType(
	ElementType elementType
)
```

## Parameters
- **elementType** (`Autodesk.Revit.DB.ElementType`) - The ElementType applied to selected instances.

## Remarks
This method uses its own transaction, so it's not permitted to be invoked in an active transaction.
 In a single invocation, the user can select multiple elements to be modified to the given type, until they finish.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This document is not the currently active one.
 -or-
 Starting a new transaction is not permitted. It could be because
 another transaction already started and has not been completed yet,
 or the document is in a state in which it cannot start a new transaction.

