---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinition.GetDescriptionText
source: html/dd0e9530-51ac-dea0-c8d1-b53162ceb51b.htm
---
# Autodesk.Revit.DB.FailureDefinition.GetDescriptionText Method

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

