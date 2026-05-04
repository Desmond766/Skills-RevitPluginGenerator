---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.SystemsFailures.DefaultSystemOver50Elems
source: html/2b86cc00-8b73-8051-3b8b-fb42e038cf9b.htm
---
# Autodesk.Revit.DB.BuiltInFailures.SystemsFailures.DefaultSystemOver50Elems Property

The default system "[Element Name]" is now over 50 elements. To improve performance, Revit is no longer calculating the critical path pressure drop and the more complex duct sizing has been disabled. If you want to use these features, you must define logical systems in the model instead of using the default system.

## Syntax (C#)
```csharp
public static FailureDefinitionId DefaultSystemOver50Elems { get; }
```

