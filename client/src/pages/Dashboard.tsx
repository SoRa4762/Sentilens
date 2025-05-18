import { useState } from "react";
import { Search, TrendingUp, BarChart2, Filter, RefreshCw } from "lucide-react";

const Dashboard = () => {
  const [activeCategory, setActiveCategory] = useState("all");

  // Mock data - replace with actual API calls
  const newsItems = [
    {
      id: 1,
      title: "Global Markets Rally After Fed Announcement",
      source: "Financial Times",
      sentiment: "positive",
      score: 0.78,
      time: "2h ago",
    },
    {
      id: 2,
      title: "Tech Layoffs Continue as Industry Faces Headwinds",
      source: "Tech Insider",
      sentiment: "negative",
      score: 0.65,
      time: "4h ago",
    },
    {
      id: 3,
      title: "New Climate Policy Receives Mixed Reactions",
      source: "Environmental Report",
      sentiment: "neutral",
      score: 0.52,
      time: "6h ago",
    },
    {
      id: 4,
      title: "Healthcare Stocks Surge on Breakthrough Treatment",
      source: "Market Watch",
      sentiment: "positive",
      score: 0.91,
      time: "8h ago",
    },
  ];

  const categories = [
    "all",
    "business",
    "technology",
    "politics",
    "health",
    "environment",
  ];

  const getSentimentColor = (sentiment: string) => {
    switch (sentiment) {
      case "positive":
        return "bg-green-100 text-green-800";
      case "negative":
        return "bg-red-100 text-red-800";
      case "neutral":
        return "bg-blue-100 text-blue-800";
      default:
        return "bg-gray-100 text-gray-800";
    }
  };

  return (
    <div className="min-h-screen bg-background p-6">
      <div className="mb-8">
        <h1 className="text-3xl font-bold mb-2">News Dashboard</h1>
        <p className="text-muted-foreground">
          Track news with sentiment analysis
        </p>
      </div>

      {/* Search and filters */}
      <div className="flex flex-col md:flex-row gap-4 mb-8">
        <div className="relative flex-grow">
          <Search className="absolute left-3 top-1/2 -translate-y-1/2 text-muted-foreground h-4 w-4" />
          <input
            type="text"
            placeholder="Search news articles..."
            className="w-full pl-10 pr-4 py-2 rounded-md border border-border bg-background"
          />
        </div>
        <div className="flex gap-2">
          <button className="flex items-center gap-2 px-4 py-2 rounded-md border border-border bg-background hover:bg-accent">
            <Filter className="h-4 w-4" /> Filters
          </button>
          <button className="flex items-center gap-2 px-4 py-2 rounded-md border border-border bg-background hover:bg-accent">
            <RefreshCw className="h-4 w-4" /> Refresh
          </button>
        </div>
      </div>

      {/* Categories */}
      <div className="flex flex-wrap gap-2 mb-8">
        {categories.map((category) => (
          <button
            key={category}
            onClick={() => setActiveCategory(category)}
            className={`px-4 py-2 rounded-md capitalize ${
              activeCategory === category
                ? "bg-primary text-primary-foreground"
                : "bg-secondary text-secondary-foreground hover:bg-accent"
            }`}
          >
            {category}
          </button>
        ))}
      </div>

      {/* Stats cards */}
      <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-8">
        <div className="bg-card p-6 rounded-lg shadow-sm">
          <div className="flex justify-between items-start">
            <div>
              <p className="text-muted-foreground mb-1">Positive Sentiment</p>
              <h3 className="text-2xl font-bold">42%</h3>
            </div>
            <div className="p-2 bg-green-100 rounded-md">
              <TrendingUp className="h-5 w-5 text-green-600" />
            </div>
          </div>
          <div className="mt-4 h-2 bg-muted rounded-full overflow-hidden">
            <div
              className="h-full bg-green-500 rounded-full"
              style={{ width: "42%" }}
            ></div>
          </div>
        </div>

        <div className="bg-card p-6 rounded-lg shadow-sm">
          <div className="flex justify-between items-start">
            <div>
              <p className="text-muted-foreground mb-1">Negative Sentiment</p>
              <h3 className="text-2xl font-bold">28%</h3>
            </div>
            <div className="p-2 bg-red-100 rounded-md">
              <TrendingUp className="h-5 w-5 text-red-600 transform rotate-180" />
            </div>
          </div>
          <div className="mt-4 h-2 bg-muted rounded-full overflow-hidden">
            <div
              className="h-full bg-red-500 rounded-full"
              style={{ width: "28%" }}
            ></div>
          </div>
        </div>

        <div className="bg-card p-6 rounded-lg shadow-sm">
          <div className="flex justify-between items-start">
            <div>
              <p className="text-muted-foreground mb-1">Neutral Sentiment</p>
              <h3 className="text-2xl font-bold">30%</h3>
            </div>
            <div className="p-2 bg-blue-100 rounded-md">
              <BarChart2 className="h-5 w-5 text-blue-600" />
            </div>
          </div>
          <div className="mt-4 h-2 bg-muted rounded-full overflow-hidden">
            <div
              className="h-full bg-blue-500 rounded-full"
              style={{ width: "30%" }}
            ></div>
          </div>
        </div>
      </div>

      {/* News list */}
      <div className="bg-card rounded-lg shadow-sm overflow-hidden">
        <div className="p-6 border-b border-border">
          <h2 className="text-xl font-bold">Latest News</h2>
        </div>
        <div className="divide-y divide-border">
          {newsItems.map((item) => (
            <div
              key={item.id}
              className="p-6 hover:bg-accent/50 transition-colors"
            >
              <div className="flex justify-between mb-2">
                <span className="text-sm text-muted-foreground">
                  {item.source}
                </span>
                <span className="text-sm text-muted-foreground">
                  {item.time}
                </span>
              </div>
              <h3 className="text-lg font-medium mb-2">{item.title}</h3>
              <div className="flex items-center gap-3">
                <span
                  className={`text-xs px-2 py-1 rounded-full ${getSentimentColor(
                    item.sentiment
                  )}`}
                >
                  {item.sentiment}
                </span>
                <div className="flex items-center gap-1">
                  <div className="h-2 w-20 bg-muted rounded-full overflow-hidden">
                    <div
                      className={`h-full rounded-full ${
                        item.sentiment === "positive"
                          ? "bg-green-500"
                          : item.sentiment === "negative"
                          ? "bg-red-500"
                          : "bg-blue-500"
                      }`}
                      style={{ width: `${item.score * 100}%` }}
                    ></div>
                  </div>
                  <span className="text-xs text-muted-foreground">
                    {(item.score * 100).toFixed(0)}%
                  </span>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Dashboard;
