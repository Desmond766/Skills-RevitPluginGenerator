---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CircuitNamingScheme.IsNameUnique(Autodesk.Revit.DB.Document,System.String)
source: html/d10a963d-f149-c47e-8af8-c816f65ae3d3.htm
---
# Autodesk.Revit.DB.Electrical.CircuitNamingScheme.IsNameUnique Method

Validates whether the CircuitNamingScheme name is unique in document.

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

