---
kind: method
id: M:Autodesk.Revit.DB.FilterElement.IsNameUnique(Autodesk.Revit.DB.Document,System.String)
source: html/43a6e9f9-9456-e18f-310f-c237ab981f6b.htm
---
# Autodesk.Revit.DB.FilterElement.IsNameUnique Method

Determines whether the given name could be applied to a new FilterElement,
 or if it could not be applied because the name is already in use.

## Syntax (C#)
```csharp
public static bool IsNameUnique(
	Document aDocument,
	string name
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document in which the name is being tested for uniqueness.
- **name** (`System.String`) - The name tested for uniqueness.

## Returns
Returns true if the name is unique, and false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

