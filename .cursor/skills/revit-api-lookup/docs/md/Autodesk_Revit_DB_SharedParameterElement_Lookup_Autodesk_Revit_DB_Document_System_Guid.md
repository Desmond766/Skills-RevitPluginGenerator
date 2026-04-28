---
kind: method
id: M:Autodesk.Revit.DB.SharedParameterElement.Lookup(Autodesk.Revit.DB.Document,System.Guid)
source: html/4dce82de-7495-523a-c8d4-4b3fc709e85e.htm
---
# Autodesk.Revit.DB.SharedParameterElement.Lookup Method

Finds the shared parameter element that corresponds to the given Guid.

## Syntax (C#)
```csharp
public static SharedParameterElement Lookup(
	Document document,
	Guid guidValue
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **guidValue** (`System.Guid`) - Shared parameter Guid.

## Returns
The retrieved shared parameter instance, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the matching element is not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

