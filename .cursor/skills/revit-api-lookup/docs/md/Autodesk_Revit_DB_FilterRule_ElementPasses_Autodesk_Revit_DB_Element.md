---
kind: method
id: M:Autodesk.Revit.DB.FilterRule.ElementPasses(Autodesk.Revit.DB.Element)
source: html/d0a73972-2d31-1e23-590a-5094367aff87.htm
---
# Autodesk.Revit.DB.FilterRule.ElementPasses Method

Derived classes override this method to implement the test that determines
 whether the given element passes this rule or not.

## Syntax (C#)
```csharp
public bool ElementPasses(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element to test against the rule.

## Returns
True if the element satisfies the rule, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

