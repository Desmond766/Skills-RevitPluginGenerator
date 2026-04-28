---
kind: type
id: T:Autodesk.Revit.DB.FilteredElementCollector
zh: 筛选、过滤
source: html/263cf06b-98be-6f91-c4da-fb47d01688f3.htm
---
# Autodesk.Revit.DB.FilteredElementCollector

**中文**: 筛选、过滤

This class is used to search, filter and iterate through a set of elements.

## Syntax (C#)
```csharp
public class FilteredElementCollector : IEnumerable<Element>, 
	IDisposable
```

## Remarks
Developers can assign a variety of conditions to filter the elements that are returned.
 This class requires that at least one condition be set before making the attempt to access the elements. Revit will attempt to organize the filters in order to minimize expansion of elements regardless of
 the order in which conditions and filters are applied. There are three groups of methods that you can use on a given collector once you have applied filter(s)
 to it. One group provides collections of all passing elements, a second finds the first match of the given
 filter(s), and a third provides an iterator that is evaluated lazily (each element is tested by the filter
 only when the iterator reaches it). You should only use
 one of the methods from these group at a time; the collector will reset if you call another method to
 extract elements. Thus, if you have previously obtained an iterator, it will be stopped and traverse no more
 elements if you call another method to extract elements. In .NET, this class supports the IEnumerable interface for Elements. You can use this class with
 LINQ queries and operations to process lists of elements. Note that because the ElementFilters
 and the shortcut methods offered by this class process elements in native code before their
 managed wrappers are generated, better performance will be obtained by using as many native filters
 as possible on the collector before attempting to process the results using LINQ queries. One special consideration when using this class in .NET: the debugger will attempt
 to traverse the members of the collector because of its implementation of IEnumerable. You may see strange
 results if you also attempt to extract the first element or all elements from the collector while the debugger
 is also looking at the contents of the collector.

