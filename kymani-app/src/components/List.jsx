// List.js
import React, { useState, useEffect } from 'react';

function List() {
  const [data, setData] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetchData();
  }, []);

  async function fetchData() {
    try {
      const response = await fetch('http://localhost:5000/api/kymanis');
      if (!response.ok) {
        throw new Error('Request failed');
      }
      const responseData = await response.json();
      setData(responseData);
    } catch (error) {
      setError(error);
    } finally {
      setIsLoading(false);
    }
  }

  const handleDataPosted = () => {
    fetchData(); 
  };

  if (isLoading) {
    return <p>There is something coming...</p>;
  }

  if (error) {
    return <p>Error: {error.message}</p>;
  }

  return (
    <div>
      <h2>Kymani Data</h2>
      <ul>
        {data.map(item => (
          <li key={item.id}>
            <h3>Kymani: {item.kymaniId}</h3>
            <p>{item.mood}</p>
            <p>{item.powerLevel}</p>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default List;
