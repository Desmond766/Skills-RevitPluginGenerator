---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinitionAccessor.GetDescriptionText
source: html/25df8b72-0a72-ddb8-212f-90eb3134ab10.htm
---
# Autodesk.Revit.DB.FailureDefinitionAccessor.GetDescriptionText Method

Retrieves the description text of the failure.

## Syntax (C#)
```csharp
public string GetDescriptionText()
```

## Returns
The description text.

## Remarks
Retrieved description text for built-in Revit failures is localized.
 The result may vary from the description text retrieved from the corresponding FailureMessage.
 A failure definition contains a description string, that may have format specifiers like %s, and "sample" strings,
 that will be used to resolve them. A FailureMessage will contain "specific" strings.
 So, in the failure definition description "Cannot keep %s joined" will be converted into "Cannot keep Element joined" while
 the description in actual FailureMessage will read "Cannot keep Walls joined" or "Cannot keep Beams joined"

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FailureDefinitionAccessor has not been properly initialized.

